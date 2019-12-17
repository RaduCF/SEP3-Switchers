drop schema Public cascade ;
create schema  Public;
set schema 'public';

CREATE TABLE if not exists Public.Users
(
username character varying(20) COLLATE pg_catalog."default" NOT NULL,
    password character varying(20) COLLATE pg_catalog."default" NOT NULL,
    firstname character varying COLLATE pg_catalog."default",
    lastname character varying COLLATE pg_catalog."default",
    email character varying(40) COLLATE pg_catalog."default" NOT NULL,
    isAdmin boolean NOT NULL,
    CONSTRAINT Users_pkey PRIMARY KEY (username)
);

CREATE TABLE IF NOT EXISTS Public.Wish(
wishId serial primary key ,
title varchar ,
URL varchar
);
CREATE TABLE IF NOT EXISTS Public.UserWish(
username varchar not null,
wishId integer NOT NULL,
primary key (wishId, username),
FOREIGN KEY          (wishId) REFERENCES Wish(wishId) ON DELETE CASCADE,
FOREIGN KEY          (username) REFERENCES Public.Users(username) ON DELETE CASCADE
);


drop table userwish cascade ;
select * from users;
select * from wish;
select * from userwish;


SELECT Wish.wishId,Wish.title, Wish.URL, UserWish.username FROM Public.Wish INNER JOIN Public.UserWish ON UserWish.wishId= Wish.wishId
SELECT UserWish.wishId,Wish.URL, Wish.Title,UserWish.username
                FROM Public.Wish INNER JOIN Public.UserWish ON Wish.wishId=UserWish.wishId
               WHERE URL='www.google.com' AND title='iphone11' AND UserWish.username='niko';
               SELECT UserWish.username,Wish.URL,Wish.title FROM Public.Wish
                INNER JOIN Public.UserWish ON UserWish.wishId=Wish.wishId
                WHERE URL='khhmnmbnh' AND title='fanbkomlse' AND UserWish.username='niko';