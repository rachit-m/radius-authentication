<?php
$conn =  mysql_connect('localhost','root','root') or die("cannot connect");
//if ($conn->connect_error) {
  //  die("Connection failed: " . $conn->connect_error);
//}
mysql_select_db("radius");
//$sql="INSERT INTO radphp (name,password,nasid) VALUES ('$argv[1]','password','$argv[2]')";
//$retval=mysql_query($sql);
//if ($argv[2]!=NULL) {
//if(true){
	//echo "radius";
$fetch="SELECT * FROM radphp WHERE SUBSTRING(State,1,10)=SUBSTRING('$argv[5]',1,10)";
$result=mysql_query($fetch);
if(($row=mysql_fetch_array($result))==NULL && $argv[5]!=NULL){
	$sql="INSERT INTO radphp VALUES ('$argv[1]','$argv[2]','$argv[3]','$argv[4]','$argv[5]',ADDTIME(now(),'05:30:00'))";
	$retval=mysql_query($sql);
	echo "Accept";
}
//}
//else 
//	echo "Reject";
mysql_close($conn);
?>



