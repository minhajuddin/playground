<?php
  //This is a page to see if other pages have access to the $_POST[] data
  function get_name(){
    return "The name is : " . $_GET['name'];
  }
?>