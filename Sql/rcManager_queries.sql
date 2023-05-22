/*

USE dbRcManager;

select * from Systems;
select * from Users;
select * from Login;
select * from Permissions;

select * from [dbo].[__EFMigrationsHistory];

delete from Permissions;
delete from Login;
delete from Systems;
delete from Users;

insert into Users(name, description, status) values ('username', 'user description', 1);
insert into Systems(name, description, status) values ('systemname', 'system description', 1);

insert into Permissions (user_id, system_id, status, date_from, date_to, weekday, weekend, start_time, end_time)
values (3, 10, 1, DATEFROMPARTS(1,1,1), DATEFROMPARTS(9,9,9), 1, 0, TIMEFROMPARTS(0,0,0,0,0), TIMEFROMPARTS(23,59,59,0,0));

select DATEFROMPARTS(1,1,1);
select DATEFROMPARTS(9,9,9);
select TIMEFROMPARTS(0,0,0,0,0);
select TIMEFROMPARTS(23,59,59,0,0);


select * from Systems;
select * from Users;
select * from Login;
select * from Permissions;


SELECT l.pk_id_login as id, l.login
FROM Login l 
INNER JOIN Users u ON (u.pk_id_user = l.fk_user_id AND u.status = 1)
WHERE l.login = 'admin'
AND l.secret = 'CE2319F52CD4EC93859101E36EFFD451D67BB82E93B184596D2AEE77D0F79AE7B87DBD2DD22837A12508EE3B28DDEC4E8A71B0313BDF2FE00F6975030527D6F8'

SELECT l.pk_id_login as id, l.login, s.[key] as system, p.date_from, p.date_to, p.weekday, p.weekend, p.start_time, p.end_time
FROM Login l 
INNER JOIN Permissions p ON (p.fk_user_id = l.fk_user_id AND p.status = 1)
INNER JOIN Systems s ON (s.pk_id_system = p.fk_system_id AND s.[key] = 'vinte' AND s.status = 1)
WHERE l.login = 'admin'
AND l.secret = 'CE2319F52CD4EC93859101E36EFFD451D67BB82E93B184596D2AEE77D0F79AE7B87DBD2DD22837A12508EE3B28DDEC4E8A71B0313BDF2FE00F6975030527D6F8'


*/
