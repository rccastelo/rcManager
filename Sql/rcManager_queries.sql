/*

USE dbRcManager;

select * from [dbo].[__EFMigrationsHistory];

select * from Systems;
select * from Users;
select * from Permissions;

delete from Permissions;
delete from Systems;
delete from Users;

insert into Users(name, description, status) values ('username', 'user description', true);

insert into Permissions (user_id, system_id, status, date_from, date_to, weekday, weekend, start_time, end_time)
values (1, 7, 1, DATEFROMPARTS(1,1,1), DATEFROMPARTS(9,9,9), 1, 0, TIMEFROMPARTS(0,0,0,0,0), TIMEFROMPARTS(23,59,59,0,0));

select DATEFROMPARTS(1,1,1);
select DATEFROMPARTS(9,9,9);
select TIMEFROMPARTS(0,0,0,0,0);
select TIMEFROMPARTS(23,59,59,0,0);

*/
