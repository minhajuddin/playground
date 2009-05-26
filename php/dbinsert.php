<?php
  $db = new mysqli('localhost','root','','scratch');
  $query = $db->prepare("INSERT INTO emp(name) VALUES('Minhajuddin')");
  $query->execute();
  echo $query->affected_rows . " rows";
  $db->close();
?>