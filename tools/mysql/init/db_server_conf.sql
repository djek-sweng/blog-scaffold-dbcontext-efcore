set default_storage_engine = innodb;

drop database if exists `db_scaffold_efcore`;
create database `db_scaffold_efcore`
    character set utf8mb4
    collate utf8mb4_unicode_ci;

use `db_scaffold_efcore`;

drop table if exists `calendars`;
create table `calendars`
(
    `id`            int unsigned not null auto_increment,
    `owner`         varchar(100) not null,
    primary key (`id`)
);

drop table if exists `meetings`;
create table `meetings`
(
    `id`            int unsigned not null auto_increment,
    `title`         varchar(200) not null,
    `description`   varchar(800) default null,
    `created_at`    datetime(6) default current_timestamp(6),
    `changed_at`    datetime(6) null on update current_timestamp(6),
    `start_at`      datetime(6) not null,
    `duration`      int unsigned not null,
    `calendar_id`   int unsigned not null,
    primary key (`id`),
    constraint `fk_meetings_calendars` foreign key (`calendar_id`) references `calendars` (`id`) on delete cascade
);

create index `ix_meetings_calendar_id` on `meetings` (`calendar_id`);

drop table if exists `reminders`;
create table `reminders`
(
    `id`            int unsigned not null auto_increment,
    `remind_before` int unsigned not null,
    `meeting_id`    int unsigned not null,
    primary key (`id`),
    constraint `fk_reminders_meetings` foreign key (`meeting_id`) references `meetings` (`id`) on delete cascade
);

create index `ix_reminders_meeting_id` on `reminders` (`meeting_id`);
