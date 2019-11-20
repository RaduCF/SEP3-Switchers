drop schema Public cascade ;
create schema  Public;
set schema 'public';
CREATE TABLE if not exists public."Users"
(

username character varying(15) COLLATE pg_catalog."default" NOT NULL,
    password character varying(9) COLLATE pg_catalog."default" NOT NULL,
    firstname character varying COLLATE pg_catalog."default",
    lastname character varying COLLATE pg_catalog."default",
    email character varying(1) COLLATE pg_catalog."default" NOT NULL,
    "isAdmin" boolean NOT NULL,
    CONSTRAINT "Users_pkey" PRIMARY KEY (username)
);
CREATE TABLE if not exists public."Wish"
(
    "URL" character varying COLLATE pg_catalog."default" NOT NULL,
    username character varying COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Wish_pkey" PRIMARY KEY ("URL"),
    CONSTRAINT username FOREIGN KEY (username)
        REFERENCES public."Users" (username) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);