# radius-authentication
Understanding Authentication of variable clients with Freeradius

For windows, EAP-TLS is the most effective method of authentication as per our experience. For other devices, we will use EAP-TTLS and PAP authentication mode. 

Authorize section in the freeradius runtime assigns a mode to the variable Auth-Type. Thats all. Depending on the Auth-Type a module runs in the authenticate mode. The module results in an accept, reject or challenge response. Post this, a post auth type of the result runs. This completes the authentication flow.


authorize {
        preprocess
        eap {
                ok = return
        }
        expiration
        logintime
    }
authenticate {
        eap
    }
    
eap module is important. It has both TLS and TTLS submodules.
    

        For EAP-TLS the handler logic is straight-forward. Unless the authentication is successful, the handler keeps on sending challenge response to the NAS. The client side connection is managed by an application which automates everything.


FOR EAP-TTLS AUTHENTICATION :

        1) Update users file
        bob     Cleartext-Password := "hello"
                Reply-Message := "Hello, %{User-Name}"
                
        This will ensure that PAP module will be set in inner tunnel

        2) Create a shortcut for inner-tunnel module
        cd /etc/freeradius/sites-enabled/
        ln -s ../sites-available/inner-tunnel ./inner-tunnel

Thats it. Connection to the server is streamlined by now.

MYSQL AS A DATA STORE

FreeRADIUS can connect to an SQL database to retrieve a user's details. The FreeRADIUS SQL modules work in pairs. A generic SQL module makes use of a specific database module to interact with the database. This allows easy support for different databases. Just as the files module uses the users file to retrieve information for authorization and authentication, so does the generic SQL module use the specific database module to retrieve the same type of information from a database.

Connection information

The sql.conf file located in the FreeRADIUS configuration directory contains all the configuration options to connect to a database. If you have used the default values, you do not have to change anything in this file. You are, however, encouraged to go through the contents of this file in order to better understand the various directives that can be specified.This will also help to double-check and confirm the values used in the previous steps.

We assume that a database named radius has already been created . Now ,we need to create a replica of the users file in MySql server which is to be used by sql module. Freeradius provides a schema for that and we just need to copy the schema in the MySql server.

mysql -u root -p radius < /etc/freeradius/sql/mysql/schema.sql

Just add 1 or more user entries in the respective tables and then change the following sql module in sql.conf file:

    sql {
    database = "mysql"  //Set the database to mysql
    driver = "rlm_sql_${database}" //Which FreeRADIUS driver to us
    # Connection info:
    server = "localhost"
    #port = 3306
    login = "root"
    password = "root"
    radius_db = "radius"//The database which we are going to use
    ………}

To let FreeRADIUS include the SQL module upon startup, uncomment the following line in radiusd.conf (/usr/local/etc/ra> ddb/radiusd.conf):

INCLUDE sql.conf

To use the SQL module as a user store, uncomment the sql line in the authorize, accounting and session sections in “/usr/freeradius/sites-enabled/default” file.

Restart freeradius in production mode (radiusd) and it will use the sql tables from now onwards.






