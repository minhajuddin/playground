<?php
  session_start();
  $_SESSION['name'] = "Khaja Minhajuddin";
  header('location: session_display.php');
?>