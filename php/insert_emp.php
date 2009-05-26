<?php
  $name = $_POST['name'];
  $db = new mysqli('localhost', 'root', '', 'scratch');
  $query = $db->prepare('INSERT INTO emp( name ) values( ? )');
  $query->bind_param('s', $name);
  $query->execute();
  echo "$query->affected_rows rows were inserted";
?>