--create database CourseDb;

--select * from UserDetail;
--create table UserDetail(UserId int primary key identity(1000,1),Name varchar(50)not null,Gender varchar(6)not null,Email varchar(50)unique not null,Password varchar(20)unique not null);
--select * from UserDetail where Email='ajay123@gmail.com' and Password='Ajay@123';




--Create table SubscriberDetails(Id int primary key identity(1,1),Email varchar(50) unique not null)
--select * from SubscriberDetails;



--create table CourseDetails (CourseId int primary key identity(100,1),CourseName varchar(100)unique not null,CourseDescription varchar(300)not null,CourseImage varchar(150)not null);
--insert into CourseDetails values('Web design','Sorem hpsum folor sixdsft amhtget, consectetur adipiscing eliht, sed do eiusmod tempor incidi.','web-design.png');
--insert into CourseDetails values('App Development','Sorem hpsum folor sixdsft amhtget, consectetur adipiscing eliht, sed do eiusmod tempor incidi.','applications.png');
--insert into CourseDetails values('Video Editing','Sorem hpsum folor sixdsft amhtget, consectetur adipiscing eliht, sed do eiusmod tempor incidi.','montage.png');
--insert into CourseDetails values('Digital Marketing','Sorem hpsum folor sixdsft amhtget, consectetur adipiscing eliht, sed do eiusmod tempor incidi.','statistics.png');
--insert into CourseDetails values('Seo Marketing','Sorem hpsum folor sixdsft amhtget, consectetur adipiscing eliht, sed do eiusmod tempor incidi.','notepad.png');
--insert into CourseDetails values('Content Writing','Sorem hpsum folor sixdsft amhtget, consectetur adipiscing eliht, sed do eiusmod tempor incidi.','light-bulb.png');

--select * from CourseDetails;

--create table FeedbackDetails(FeedbackId int primary key identity(1,1) ,Name varchar(40) not null,Email varchar(50) unique not null,Subject varchar(50) not null,FeedbackMessage varchar(300) not null );
--select * from FeedbackDetails;

--create table BlogDetails(BlogId int primary key identity(1,1),BlogName varchar(50)not null,BlogDetails varchar(1000)not null,BloggerName varchar(50)not null,BloggerImage varchar(500) ,BlogDate Date not null);

--select * from BlogDetails;

--insert into BlogDetails values('App Development','Example about App Developement?','Jacob','light-bulb.png','2022/09/28');
--insert into BlogDetails values('Web Development','Example about Web Developement?','Ajay','light-bulb.png','2022/10/28');

--create table UserCourses(S_No int primary key Identity(1,1),UserId int , CourseId int,foreign key(UserId) references UserDetail(UserId),foreign key(CourseId) references CourseDetails(CourseId));
select * from BlogDetails;



