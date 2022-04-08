create schema animalpaws;
use animalpaws;
create table posts(
idpost int auto_increment not null primary key,
post_title varchar(20),
post_description varchar(80),
url_img varchar(80),
post_category varchar(20)
);

create table associations (
id_association int not null  auto_increment key,
name_association varchar(60) not null,
add_association varchar(80) not null,
desc_association text not null,
phone_association int not null,
sponsor_association varchar(60) not null,
schedule_association varchar(60) not null
);

create table users(
id int auto_increment primary key,
names varchar(60),
last_name varchar(60),
username varchar(60),
description varchar(80)
);

insert into posts (post_title, post_description, url_img, post_category)
values ('First Test', 'Is Just A Test', 'https://i.imgur.com/1oCTuhw.png', 'Donation');
insert into posts (post_title, post_description, url_img, post_category)
values ('Second Test', 'Is Just A Second Test', 'https://i.imgur.com/kSB4FlF.png', 'Donation');
insert into posts (post_title, post_description, url_img, post_category)
values ('Third Test', 'Is Just A Third Test', 'https://i.imgur.com/YbYWCSz.jpeg', 'Adoption');

insert into associations (name_association, add_association, desc_association, phone_association, sponsor_association, schedule_association)
values('Association Test 1', 'Is Just A Test', 'Association Test N1', '123456', 'Paws Rescue', '17:00');
insert into associations (name_association, add_association, desc_association, phone_association, sponsor_association, schedule_association)
values('Association Test 2', 'Is Juts A Second Test', 'Association Test N2', '123456', 'Paws Rescue Rebirth', '20:00');
insert into associations (name_association, add_association, desc_association, phone_association, sponsor_association, schedule_association)
values('Association Test 3', 'Is Just A Third Test', 'Association Test N3', '123456', 'Paws Rescue Remake', '13:00');

insert into users(names, last_name, username, description)
values('Julian', 'Lozada', 'Ex1', 'My Description Is So Boring, Right?')
insert into users(names, last_name, username, description)
values('Angie', 'Lugo', 'Humming Moon', 'No Description Provided...')
insert into users(names, last_name, username, description)
values('Camilo', 'Cruz', 'Ragnarok', 'No Description Provided...')