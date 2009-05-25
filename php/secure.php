<?php
// Starting the session
session_start();

if(isset($_SESSION['user']))
    {
        // Code for Logged members
      
        // Identifying the user
        $user = $_SESSION['user'];
        echo "Welcome $user";
       
        // Information for the user.
    }
else
    {
        // Code to show Guests
        echo "You haven't logged in ";
    }
?>
