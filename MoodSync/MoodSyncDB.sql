
DROP DATABASE IF EXISTS MoodSyncDB;

CREATE DATABASE IF NOT EXISTS MoodSyncDB;
USE MoodSyncDB;

DROP TABLE IF EXISTS Users;


CREATE TABLE Users (
    UserID INT NOT NULL AUTO_INCREMENT,      
    UserName VARCHAR(50) NOT NULL,           
    Password VARCHAR(255) NOT NULL,          
    Email VARCHAR(100) NOT NULL,             
    PRIMARY KEY (UserID)                      
);

