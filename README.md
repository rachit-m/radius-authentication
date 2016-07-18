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






