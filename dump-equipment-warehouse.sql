--
-- PostgreSQL database dump
--

\restrict VFtBmnMZKmg82W9kCDzSfZ4QO5Hj8yohn71gqMm2OOXHz2ollb0urhuncVRflqE

-- Dumped from database version 18.0
-- Dumped by pg_dump version 18.0

-- Started on 2026-03-13 13:07:08

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE equipment_warehouse;
--
-- TOC entry 5045 (class 1262 OID 58476)
-- Name: equipment_warehouse; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE equipment_warehouse WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';


ALTER DATABASE equipment_warehouse OWNER TO postgres;

\unrestrict VFtBmnMZKmg82W9kCDzSfZ4QO5Hj8yohn71gqMm2OOXHz2ollb0urhuncVRflqE
\connect equipment_warehouse
\restrict VFtBmnMZKmg82W9kCDzSfZ4QO5Hj8yohn71gqMm2OOXHz2ollb0urhuncVRflqE

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 223 (class 1259 OID 58542)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 58477)
-- Name: countries; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.countries (
    "Id" uuid NOT NULL,
    "Name" character varying(70) NOT NULL,
    "Code" character varying(2) NOT NULL
);


ALTER TABLE public.countries OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 58485)
-- Name: device_types; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.device_types (
    "Id" uuid NOT NULL,
    "Name" character varying(70) NOT NULL,
    "Description" character varying(511),
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone NOT NULL
);


ALTER TABLE public.device_types OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 58496)
-- Name: manufacturers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.manufacturers (
    "Id" uuid NOT NULL,
    "Name" character varying(70) NOT NULL,
    "Description" character varying(511),
    "CreatedAt" timestamp with time zone NOT NULL,
    "UpdatedAt" timestamp with time zone NOT NULL
);


ALTER TABLE public.manufacturers OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 58507)
-- Name: nomenclatures; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.nomenclatures (
    "Id" uuid NOT NULL,
    "Url" text NOT NULL,
    "Caption" character varying(200) NOT NULL,
    "DeviceTypeId" uuid NOT NULL,
    "ManufacturerId" uuid NOT NULL,
    "ModelName" character varying(100) NOT NULL,
    "CountryId" uuid NOT NULL,
    "Price" numeric(18,2) NOT NULL,
    "CreateAt" timestamp with time zone NOT NULL,
    "UpdateAt" timestamp with time zone NOT NULL,
    "Currency" character varying(3) DEFAULT ''::character varying NOT NULL
);


ALTER TABLE public.nomenclatures OWNER TO postgres;

--
-- TOC entry 5039 (class 0 OID 58542)
-- Dependencies: 223
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" VALUES ('20260309223033_FixNomenclaturePrice', '8.0.24');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20260302105959_InitialCreate', '8.0.24');


--
-- TOC entry 5035 (class 0 OID 58477)
-- Dependencies: 219
-- Data for Name: countries; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.countries VALUES ('55a94412-38f0-42c7-94fc-349cd2ba464a', 'Китай', 'CN');
INSERT INTO public.countries VALUES ('54792df9-b501-4b2b-ab8d-cc59bbd36a82', 'Германия', 'GE');
INSERT INTO public.countries VALUES ('2a39d66a-5742-4b60-b3a0-1ebaca14077c', 'Россия', 'RU');
INSERT INTO public.countries VALUES ('bda8fb88-7963-4b8f-af7c-20a970eacb7c', 'Малазия', 'MY');
INSERT INTO public.countries VALUES ('b9a98e5b-285e-4f76-82b9-a571df7c5a6c', 'Korea', 'KO');
INSERT INTO public.countries VALUES ('ef672b58-b21e-4f44-9e83-b9322283bfe7', 'Мексика', 'TC');
INSERT INTO public.countries VALUES ('9be4a5a9-d17c-4521-bd57-d0e143e88831', 'Аргентина', 'TC');
INSERT INTO public.countries VALUES ('94bffbcc-1b95-4e2d-af13-a2037a99a99f', 'ЮАР', 'TC');
INSERT INTO public.countries VALUES ('f99377ad-6dc4-4166-9b7b-e637a186832a', 'США', 'TC');


--
-- TOC entry 5036 (class 0 OID 58485)
-- Dependencies: 220
-- Data for Name: device_types; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.device_types VALUES ('d2e03ec6-ca12-4b71-bf70-5804444dde18', 'Пылесос', 'Новое описание, не длинное', '2026-03-05 11:16:31.849+03', '2026-03-08 00:17:17.565321+03');
INSERT INTO public.device_types VALUES ('47e5cdde-4577-4ffe-8e48-a135ce581d61', 'Микрофон 123', 'Записывает звук', '2026-03-05 11:16:31.849+03', '2026-03-12 12:46:02.168095+03');
INSERT INTO public.device_types VALUES ('15d94efb-feab-490b-b159-fc21b7096b7f', 'Смартфон', 'orem Ipsum is123mply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the le', '2026-03-05 11:16:31.84972+03', '2026-03-12 12:47:55.583703+03');
INSERT INTO public.device_types VALUES ('11111111-1111-1111-1111-111111111111', 'Маршрутизатор', 'Сетевое устройство для маршрутизации трафика', '2025-01-15 08:30:00+03', '2025-01-15 08:30:00+03');
INSERT INTO public.device_types VALUES ('22222222-2222-2222-2222-222222222222', 'Коммутатор', 'Устройство для соединения компьютеров в сети', '2025-01-15 08:35:00+03', '2025-01-15 08:35:00+03');
INSERT INTO public.device_types VALUES ('33333333-3333-3333-3333-333333333333', 'Точка доступа', 'Беспроводное устройство для доступа к сети', '2025-01-15 08:40:00+03', '2025-01-15 08:40:00+03');
INSERT INTO public.device_types VALUES ('44444444-4444-4444-4444-444444444444', 'Принтер', 'Устройство для печати документов', '2025-01-15 08:45:00+03', '2025-01-15 08:45:00+03');
INSERT INTO public.device_types VALUES ('55555555-5555-5555-5555-555555555555', 'Сканер', 'Устройство для сканирования документов', '2025-01-15 08:50:00+03', '2025-01-15 08:50:00+03');
INSERT INTO public.device_types VALUES ('66666666-6666-6666-6666-666666666666', 'Ноутбук', 'Портативный компьютер', '2025-01-15 08:55:00+03', '2025-01-15 08:55:00+03');
INSERT INTO public.device_types VALUES ('77777777-7777-7777-7777-777777777777', 'Сервер', 'Высокопроизводительный компьютер для серверных задач', '2025-01-15 09:00:00+03', '2025-01-15 09:00:00+03');
INSERT INTO public.device_types VALUES ('88888888-8888-8888-8888-888888888888', 'Монитор', 'Устройство визуального отображения информации', '2025-01-15 09:05:00+03', '2025-01-15 09:05:00+03');
INSERT INTO public.device_types VALUES ('99999999-9999-9999-9999-999999999999', 'Клавиатура', 'Устройство ввода текста', '2025-01-15 09:10:00+03', '2025-01-15 09:10:00+03');
INSERT INTO public.device_types VALUES ('aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa', 'Мышь', 'Устройство позиционирования курсора', '2025-01-15 09:15:00+03', '2025-01-15 09:15:00+03');
INSERT INTO public.device_types VALUES ('bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb', 'Веб-камера', 'Устройство для видеозахвата', '2025-01-15 09:20:00+03', '2025-01-15 09:20:00+03');
INSERT INTO public.device_types VALUES ('cccccccc-cccc-cccc-cccc-cccccccccccc', 'Микрофон', 'Устройство для записи звука', '2025-01-15 09:25:00+03', '2025-01-15 09:25:00+03');
INSERT INTO public.device_types VALUES ('dddddddd-dddd-dddd-dddd-dddddddddddd', 'Колонки', 'Устройство для воспроизведения звука', '2025-01-15 09:30:00+03', '2025-01-15 09:30:00+03');
INSERT INTO public.device_types VALUES ('eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee', 'Наушники', 'Персональное устройство для прослушивания', '2025-01-15 09:35:00+03', '2025-01-15 09:35:00+03');
INSERT INTO public.device_types VALUES ('ffffffff-ffff-ffff-ffff-ffffffffffff', 'Планшет', 'Портативное устройство с сенсорным экраном', '2025-01-15 09:40:00+03', '2025-01-15 09:40:00+03');
INSERT INTO public.device_types VALUES ('a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1', 'Смартфон', 'Мобильное устройство связи', '2025-01-15 09:45:00+03', '2025-01-15 09:45:00+03');
INSERT INTO public.device_types VALUES ('b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2', 'Смарт-часы', 'Носимые устройства с функциями смартфона', '2025-01-15 09:50:00+03', '2025-01-15 09:50:00+03');
INSERT INTO public.device_types VALUES ('c3c3c3c3-c3c3-c3c3-c3c3-c3c3c3c3c3c3', 'Фитнес-браслет', 'Устройство для отслеживания активности', '2025-01-15 09:55:00+03', '2025-01-15 09:55:00+03');
INSERT INTO public.device_types VALUES ('d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4', 'ИБП', 'Источник бесперебойного питания', '2025-01-15 10:00:00+03', '2025-01-15 10:00:00+03');
INSERT INTO public.device_types VALUES ('e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5', 'МФУ', 'Многофункциональное устройство', '2025-01-15 10:05:00+03', '2025-01-15 10:05:00+03');
INSERT INTO public.device_types VALUES ('f6f6f6f6-f6f6-f6f6-f6f6-f6f6f6f6f6f6', 'Проектор', 'Устройство для проекции изображения', '2025-01-15 10:10:00+03', '2025-01-15 10:10:00+03');
INSERT INTO public.device_types VALUES ('3c4d5e6f-3c4d-3c4d-3c4d-3c4d5e6f7a8b', 'Видеорегистратор', 'Устройство для записи видео', '2025-01-15 10:25:00+03', '2025-01-15 10:25:00+03');
INSERT INTO public.device_types VALUES ('6f7a8b9c-6f7a-6f7a-6f7a-6f7a8b9c0d1e', 'Электронный замок', 'Устройство для блокировки дверей', '2025-01-15 10:40:00+03', '2025-01-15 10:40:00+03');
INSERT INTO public.device_types VALUES ('7a8b9c0d-7a8b-7a8b-7a8b-7a8b9c0d1e2f', 'Считыватель карт', 'Устройство для чтения RFID-карт', '2025-01-15 10:45:00+03', '2025-01-15 10:45:00+03');
INSERT INTO public.device_types VALUES ('8b9c0d1e-8b9c-8b9c-8b9c-8b9c0d1e2f3a', 'Контроллер доступа', 'Устройство управления доступом', '2025-01-15 10:50:00+03', '2025-01-15 10:50:00+03');
INSERT INTO public.device_types VALUES ('9c0d1e2f-9c0d-9c0d-9c0d-9c0d1e2f3a4b', 'Датчик движения', 'Сенсор для обнаружения движения', '2025-01-15 10:55:00+03', '2025-01-15 10:55:00+03');
INSERT INTO public.device_types VALUES ('0d1e2f3a-0d1e-0d1e-0d1e-0d1e2f3a4b5c', 'Датчик открытия', 'Сенсор для контроля открытия дверей/окон', '2025-01-15 11:00:00+03', '2025-01-15 11:00:00+03');
INSERT INTO public.device_types VALUES ('1e2f3a4b-1e2f-1e2f-1e2f-1e2f3a4b5c6d', 'Датчик дыма', 'Пожарный извещатель', '2025-01-15 11:05:00+03', '2025-01-15 11:05:00+03');
INSERT INTO public.device_types VALUES ('2f3a4b5c-2f3a-2f3a-2f3a-2f3a4b5c6d7e', 'Датчик утечки газа', 'Сенсор для обнаружения газа', '2025-01-15 11:10:00+03', '2025-01-15 11:10:00+03');
INSERT INTO public.device_types VALUES ('3a4b5c6d-3a4b-3a4b-3a4b-3a4b5c6d7e8f', 'Датчик протечки воды', 'Сенсор для обнаружения воды', '2025-01-15 11:15:00+03', '2025-01-15 11:15:00+03');
INSERT INTO public.device_types VALUES ('4b5c6d7e-4b5c-4b5c-4b5c-4b5c6d7e8f9a', 'Термостат', 'Устройство для контроля температуры', '2025-01-15 11:20:00+03', '2025-01-15 11:20:00+03');
INSERT INTO public.device_types VALUES ('5c6d7e8f-5c6d-5c6d-5c6d-5c6d7e8f9a0b', 'Умная розетка', 'Розетка с удаленным управлением', '2025-01-15 11:25:00+03', '2025-01-15 11:25:00+03');
INSERT INTO public.device_types VALUES ('6d7e8f9a-6d7e-6d7e-6d7e-6d7e8f9a0b1c', 'Умная лампа', 'Осветительный прибор с управлением', '2025-01-15 11:30:00+03', '2025-01-15 11:30:00+03');
INSERT INTO public.device_types VALUES ('7e8f9a0b-7e8f-7e8f-7e8f-7e8f9a0b1c2d', 'Шлюз умного дома', 'Центральное устройство умного дома', '2025-01-15 11:35:00+03', '2025-01-15 11:35:00+03');
INSERT INTO public.device_types VALUES ('8f9a0b1c-8f9a-8f9a-8f9a-8f9a0b1c2d3e', 'Робот-пылесос', 'Автоматическое устройство для уборки', '2025-01-15 11:40:00+03', '2025-01-15 11:40:00+03');
INSERT INTO public.device_types VALUES ('9a0b1c2d-9a0b-9a0b-9a0b-9a0b1c2d3e4f', 'Метеостанция', 'Устройство для измерения погоды', '2025-01-15 11:45:00+03', '2025-01-15 11:45:00+03');
INSERT INTO public.device_types VALUES ('0b1c2d3e-0b1c-0b1c-0b1c-0b1c2d3e4f5a', 'ТВ-приставка', 'Устройство для цифрового телевидения', '2025-01-15 11:50:00+03', '2025-01-15 11:50:00+03');
INSERT INTO public.device_types VALUES ('1c2d3e4f-1c2d-1c2d-1c2d-1c2d3e4f5a6b', 'Медиаплеер', 'Устройство для воспроизведения медиа', '2025-01-15 11:55:00+03', '2025-01-15 11:55:00+03');
INSERT INTO public.device_types VALUES ('2d3e4f5a-2d3e-2d3e-2d3e-2d3e4f5a6b7c', 'Игровая консоль', 'Устройство для видеоигр', '2025-01-15 12:00:00+03', '2025-01-15 12:00:00+03');
INSERT INTO public.device_types VALUES ('3e4f5a6b-3e4f-3e4f-3e4f-3e4f5a6b7c8d', 'VR-шлем', 'Устройство виртуальной реальности', '2025-01-15 12:05:00+03', '2025-01-15 12:05:00+03');
INSERT INTO public.device_types VALUES ('4f5a6b7c-4f5a-4f5a-4f5a-4f5a6b7c8d9e', 'Джойстик', 'Устройство управления для игр', '2025-01-15 12:10:00+03', '2025-01-15 12:10:00+03');
INSERT INTO public.device_types VALUES ('5a6b7c8d-5a6b-5a6b-5a6b-5a6b7c8d9e0f', 'Руль', 'Игровой контроллер для автосимуляторов', '2025-01-15 12:15:00+03', '2025-01-15 12:15:00+03');
INSERT INTO public.device_types VALUES ('6b7c8d9e-6b7c-6b7c-6b7c-6b7c8d9e0f1a', 'Внешний жесткий диск', 'Устройство для хранения данных', '2025-01-15 12:20:00+03', '2025-01-15 12:20:00+03');
INSERT INTO public.device_types VALUES ('7c8d9e0f-7c8d-7c8d-7c8d-7c8d9e0f1a2b', 'SSD-накопитель', 'Твердотельный накопитель', '2025-01-15 12:25:00+03', '2025-01-15 12:25:00+03');
INSERT INTO public.device_types VALUES ('8d9e0f1a-8d9e-8d9e-8d9e-8d9e0f1a2b3c', 'Флеш-накопитель', 'Портативное USB-устройство', '2025-01-15 12:30:00+03', '2025-01-15 12:30:00+03');
INSERT INTO public.device_types VALUES ('9e0f1a2b-9e0f-9e0f-9e0f-9e0f1a2b3c4d', 'Карта памяти', 'Носитель для цифровых устройств', '2025-01-15 12:35:00+03', '2025-01-15 12:35:00+03');
INSERT INTO public.device_types VALUES ('0f1a2b3c-0f1a-0f1a-0f1a-0f1a2b3c4d5e', 'Картридер', 'Устройство для чтения карт памяти', '2025-01-15 12:40:00+03', '2025-01-15 12:40:00+03');
INSERT INTO public.device_types VALUES ('1a2b3c4d-1a2b-1a2b-1a2b-1a2b3c4d5e6f', 'USB-концентратор', 'Устройство для расширения USB-портов', '2025-01-15 12:45:00+03', '2025-01-15 12:45:00+03');
INSERT INTO public.device_types VALUES ('4d5e6f7a-4d5e-4d5e-4d5e-4d5e6f7a8b9c', 'Bluetooth-адаптер', 'Устройство для подключения по Bluetooth', '2025-01-15 13:00:00+03', '2025-01-15 13:00:00+03');
INSERT INTO public.device_types VALUES ('2b3c4d5e-2b3c-2b3c-2b3c-2b3c4d5e6f7a', 'Утюг', 'Устройство для глажки', '2025-01-15 15:20:00+03', '2025-01-15 15:20:00+03');
INSERT INTO public.device_types VALUES ('5e6f7a8b-5e6f-5e6f-5e6f-5e6f7a8b9c0d', 'Швейная машина', 'Устройство для шитья', '2025-01-15 15:35:00+03', '2025-01-15 15:35:00+03');
INSERT INTO public.device_types VALUES ('8e20b4cb-afbe-448f-905f-ee4536ce1198', 'dfgzdfg', 'drgdrfg', '2026-03-08 17:40:16.292857+03', '2026-03-08 17:40:16.292858+03');
INSERT INTO public.device_types VALUES ('6ca4986f-9280-4caf-91d0-996cfd1561fd', 'Новый тип устройства', 'fhd', '2026-03-08 17:43:37.609057+03', '2026-03-08 17:43:37.609057+03');
INSERT INTO public.device_types VALUES ('862687c7-c54f-47fb-b81d-654f8b9ddf14', 'Новый тип устройства', 'fdgzfdg', '2026-03-08 17:47:38.344852+03', '2026-03-08 17:47:38.344853+03');
INSERT INTO public.device_types VALUES ('1de2e2cf-f1eb-4217-8c95-ba1d6ab627a7', 'Новый тип устройства', '', '2026-03-12 12:47:44.13847+03', '2026-03-12 12:47:44.13847+03');


--
-- TOC entry 5037 (class 0 OID 58496)
-- Dependencies: 221
-- Data for Name: manufacturers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0002-4e5f-8a9b-c0d1e2f30002', 'Samsung', 'Южнокорейский технологический конгломерат, производитель электроники, бытовой техники и полупроводников.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0003-4e5f-8a9b-c0d1e2f30003', 'Apple', 'Американская компания, производитель потребительской электроники, программного обеспечения и онлайн-сервисов.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0004-4e5f-8a9b-c0d1e2f30004', 'Bosch', 'Немецкая международная инжиниринговая и технологическая компания, производитель автозапчастей и бытовой техники.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0005-4e5f-8a9b-c0d1e2f30005', 'Sony', 'Японский многонациональный конгломерат, производитель электроники, игровых консолей и медиапродуктов.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0006-4e5f-8a9b-c0d1e2f30006', 'Siemens', 'Немецкий технологический гигант, специализирующийся на промышленной автоматизации, энергетике и медицинском оборудовании.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0007-4e5f-8a9b-c0d1e2f30007', 'Nike', 'Американский производитель спортивной одежды, обуви и аксессуаров. Один из мировых лидеров спортивной индустрии.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0008-4e5f-8a9b-c0d1e2f30008', 'Philips', 'Нидерландская технологическая компания, специализирующаяся на медицинском оборудовании, освещении и бытовой электронике.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0009-4e5f-8a9b-c0d1e2f30009', 'LG Electronics', 'Южнокорейский производитель электроники, бытовой техники и мобильных устройств.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0010-4e5f-8a9b-c0d1e2f30010', 'Intel', 'Американская транснациональная корпорация, один из крупнейших производителей процессоров и полупроводниковых компонентов.', '2024-01-01 08:00:00+03', '2024-01-01 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0011-4e5f-8a9b-c0d1e2f30011', 'Adidas', 'Немецкий производитель спортивной одежды и обуви. Второй по величине производитель спортивных товаров в мире.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0012-4e5f-8a9b-c0d1e2f30012', 'Panasonic', 'Японская многонациональная электронная корпорация, производитель бытовой техники и промышленного оборудования.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0013-4e5f-8a9b-c0d1e2f30013', 'Honda', 'Японский производитель автомобилей и мотоциклов, основанный в 1948 году.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0014-4e5f-8a9b-c0d1e2f30014', 'Microsoft', 'Американская технологическая корпорация, разработчик программного обеспечения, операционных систем и облачных сервисов.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0015-4e5f-8a9b-c0d1e2f30015', 'Canon', 'Японский производитель фотооборудования, офисной техники и оптических приборов.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0016-4e5f-8a9b-c0d1e2f30016', 'Caterpillar', 'Американский производитель строительной и горнодобывающей техники, дизельных двигателей и промышленного оборудования.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0017-4e5f-8a9b-c0d1e2f30017', 'Nestlé', 'Швейцарская пищевая компания, крупнейший в мире производитель продуктов питания и напитков.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0018-4e5f-8a9b-c0d1e2f30018', 'NVIDIA', 'Американский производитель графических процессоров и систем на чипе для игровой и профессиональной отраслей.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0019-4e5f-8a9b-c0d1e2f30019', 'Volkswagen', 'Немецкий автомобильный концерн, один из крупнейших в мире, включающий бренды Audi, Porsche, Skoda и другие.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0020-4e5f-8a9b-c0d1e2f30020', '3M', 'Американская многоотраслевая корпорация, производитель промышленных товаров, товаров для дома и медицинских изделий.', '2024-01-02 08:00:00+03', '2024-01-02 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0021-4e5f-8a9b-c0d1e2f30021', 'Unilever', 'Британско-нидерландская компания, один из крупнейших производителей товаров повседневного спроса в мире.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0022-4e5f-8a9b-c0d1e2f30022', 'ABB', 'Швейцарско-шведский многонациональный концерн, специализирующийся на робототехнике, энергетике и автоматизации.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0023-4e5f-8a9b-c0d1e2f30023', 'Procter & Gamble', 'Американская многонациональная компания, производитель потребительских товаров, включая средства гигиены и косметику.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0024-4e5f-8a9b-c0d1e2f30024', 'Hitachi', 'Японский транснациональный конгломерат, производитель электроники, строительного и горного оборудования.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0025-4e5f-8a9b-c0d1e2f30025', 'Michelin', 'Французская компания, один из крупнейших производителей шин в мире. Основана в 1889 году.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0026-4e5f-8a9b-c0d1e2f30026', 'Airbus', 'Европейский авиастроительный концерн, производитель коммерческих самолётов, вертолётов и аэрокосмической техники.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0027-4e5f-8a9b-c0d1e2f30027', 'Boeing', 'Американский авиастроительный и аэрокосмический концерн, один из крупнейших производителей самолётов в мире.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0028-4e5f-8a9b-c0d1e2f30028', 'Haier', 'Китайская многонациональная компания, один из крупнейших в мире производителей бытовой техники.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0029-4e5f-8a9b-c0d1e2f30029', 'BASF', 'Немецкая химическая компания, крупнейший в мире производитель химической продукции.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0030-4e5f-8a9b-c0d1e2f30030', 'Honeywell', 'Американский многоотраслевой производитель промышленного оборудования, авиационных систем и средств безопасности.', '2024-01-03 08:00:00+03', '2024-01-03 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0031-4e5f-8a9b-c0d1e2f30031', 'Komatsu', 'Японский производитель строительной и горнодобывающей техники, второй в мире по объёму производства.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0032-4e5f-8a9b-c0d1e2f30032', 'Huawei', 'Китайская транснациональная технологическая компания, производитель телекоммуникационного оборудования и смартфонов.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0033-4e5f-8a9b-c0d1e2f30033', 'Whirlpool', 'Американская транснациональная корпорация, один из крупнейших производителей бытовой техники в мире.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0034-4e5f-8a9b-c0d1e2f30034', 'Schneider Electric', 'Французская транснациональная корпорация, специализирующаяся на управлении энергией и автоматизации.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0035-4e5f-8a9b-c0d1e2f30035', 'Nikon', 'Японский производитель оптического оборудования, фотокамер и медицинских приборов.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0036-4e5f-8a9b-c0d1e2f30036', 'Bridgestone', 'Японская компания, крупнейший в мире производитель шин и резинотехнических изделий.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0037-4e5f-8a9b-c0d1e2f30037', 'Henkel', 'Немецкая химическая и потребительская компания, производитель клеёв, моющих средств и косметики.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0038-4e5f-8a9b-c0d1e2f30038', 'Emerson Electric', 'Американская многонациональная корпорация, производитель промышленного оборудования и инструментов для автоматизации.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0039-4e5f-8a9b-c0d1e2f30039', 'Fujifilm', 'Японский производитель фотоплёнки, медицинского оборудования и офисных продуктов.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0040-4e5f-8a9b-c0d1e2f30040', 'Puma', 'Немецкая компания, производитель спортивной одежды, обуви и аксессуаров. Основана в 1948 году.', '2024-01-04 08:00:00+03', '2024-01-04 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0041-4e5f-8a9b-c0d1e2f30041', 'General Electric', 'Американский многоотраслевой конгломерат, производитель авиадвигателей, энергетического и медицинского оборудования.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0042-4e5f-8a9b-c0d1e2f30042', 'Xiaomi', 'Китайская технологическая компания, производитель смартфонов, умных устройств и бытовой техники.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0043-4e5f-8a9b-c0d1e2f30043', 'Toshiba', 'Японский многонациональный конгломерат, производитель электроники, инфраструктурного и промышленного оборудования.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0044-4e5f-8a9b-c0d1e2f30044', 'Lenovo', 'Китайская транснациональная технологическая компания, крупнейший в мире производитель персональных компьютеров.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0045-4e5f-8a9b-c0d1e2f30045', 'Dupont', 'Американская химическая компания, один из крупнейших производителей специальных материалов и химикатов.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0046-4e5f-8a9b-c0d1e2f30046', 'Rolls-Royce', 'Британский производитель авиационных двигателей, морских силовых установок и энергетических систем.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0047-4e5f-8a9b-c0d1e2f30047', 'Hyundai', 'Южнокорейский автомобильный производитель, входящий в десятку крупнейших в мире.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0048-4e5f-8a9b-c0d1e2f30048', 'Casio', 'Японская компания, производитель электроники, часов, калькуляторов и музыкальных инструментов.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0049-4e5f-8a9b-c0d1e2f30049', 'Lockheed Martin', 'Американская аэрокосмическая и оборонная компания, крупнейший в мире оборонный подрядчик.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0050-4e5f-8a9b-c0d1e2f30050', 'Epson', 'Японский производитель принтеров, проекторов, промышленных роботов и электронных компонентов.', '2024-01-05 08:00:00+03', '2024-01-05 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0051-4e5f-8a9b-c0d1e2f30051', 'Suzuki', 'Японский производитель автомобилей и мотоциклов, известный компактными и доступными моделями.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0052-4e5f-8a9b-c0d1e2f30052', 'Volvo', 'Шведский производитель грузовых автомобилей, автобусов и строительного оборудования.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0053-4e5f-8a9b-c0d1e2f30053', 'Caterpillar Financial', 'Дочерняя финансовая компания Caterpillar Inc., предоставляющая финансовые услуги для покупателей техники.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0054-4e5f-8a9b-c0d1e2f30054', 'Texas Instruments', 'Американская компания, разработчик и производитель полупроводников и встраиваемых процессоров.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0055-4e5f-8a9b-c0d1e2f30055', 'Qualcomm', 'Американская полупроводниковая компания, крупнейший в мире разработчик процессоров для мобильных устройств.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0056-4e5f-8a9b-c0d1e2f30056', 'Kimberly-Clark', 'Американская корпорация, производитель товаров личной гигиены под брендами Huggies и Kleenex.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0057-4e5f-8a9b-c0d1e2f30057', 'Danfoss', 'Датская компания, производитель энергосберегающего оборудования, систем охлаждения и привода.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0058-4e5f-8a9b-c0d1e2f30058', 'Fanuc', 'Японская компания, один из мировых лидеров в производстве промышленных роботов и станков с ЧПУ.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0059-4e5f-8a9b-c0d1e2f30059', 'Mitsubishi Electric', 'Японский производитель электронного и электрического оборудования для промышленности и потребительского рынка.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0060-4e5f-8a9b-c0d1e2f30060', 'Thales', 'Французская многонациональная компания, специализирующаяся на аэрокосмической, оборонной и транспортной технике.', '2024-01-06 08:00:00+03', '2024-01-06 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0061-4e5f-8a9b-c0d1e2f30061', 'Yamaha', 'Японская компания, производитель музыкальных инструментов, мотоциклов, морских двигателей и аудиооборудования.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0062-4e5f-8a9b-c0d1e2f30062', 'Sandvik', 'Шведская инжиниринговая компания, производитель горного оборудования, режущих инструментов и металлических материалов.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0063-4e5f-8a9b-c0d1e2f30063', 'Parker Hannifin', 'Американская корпорация, мировой лидер в области технологий и систем управления движением.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0064-4e5f-8a9b-c0d1e2f30064', 'Asus', 'Тайваньская транснациональная компания, производитель компьютеров, ноутбуков, материнских плат и смартфонов.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0065-4e5f-8a9b-c0d1e2f30065', 'Eaton', 'Американская компания, производитель систем управления электрическим питанием и гидравлического оборудования.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0066-4e5f-8a9b-c0d1e2f30066', 'Hella', 'Немецкий производитель автомобильных осветительных систем и электронных компонентов.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0067-4e5f-8a9b-c0d1e2f30067', 'Harman', 'Американская компания, дочерняя Samsung, производитель аудиооборудования и систем для автомобилей.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0068-4e5f-8a9b-c0d1e2f30068', 'Kennametal', 'Американский производитель твёрдосплавных инструментов и решений для металлообработки.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0069-4e5f-8a9b-c0d1e2f30069', 'Henkel Adhesives', 'Подразделение Henkel, специализирующееся на промышленных клеях и герметиках для различных отраслей.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0070-4e5f-8a9b-c0d1e2f30070', 'Victaulic', 'Американская компания, производитель трубопроводной арматуры и соединительных систем для промышленного применения.', '2024-01-07 08:00:00+03', '2024-01-07 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0071-4e5f-8a9b-c0d1e2f30071', 'Atlas Copco', 'Шведская промышленная группа, производитель компрессоров, вакуумного и горнодобывающего оборудования.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0072-4e5f-8a9b-c0d1e2f30072', 'Leica', 'Немецкий производитель прецизионной оптики, фотоаппаратов и геодезических инструментов.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0073-4e5f-8a9b-c0d1e2f30073', 'Zeiss', 'Немецкая оптическая компания, производитель микроскопов, промышленных измерительных приборов и очковой оптики.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0074-4e5f-8a9b-c0d1e2f30074', 'SKF', 'Шведская компания, один из ведущих мировых производителей подшипников, уплотнений и смазочных систем.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0075-4e5f-8a9b-c0d1e2f30075', 'Rockwell Automation', 'Американский производитель промышленной автоматизации и информационных технологий.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0076-4e5f-8a9b-c0d1e2f30076', 'Wacker Chemie', 'Немецкая химическая компания, производитель силиконов, полимерных продуктов и поликристаллического кремния.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0077-4e5f-8a9b-c0d1e2f30077', 'Yokogawa', 'Японская компания, производитель измерительных приборов, промышленной автоматизации и медицинского оборудования.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0078-4e5f-8a9b-c0d1e2f30078', 'Daikin', 'Японский производитель систем кондиционирования воздуха, холодильного оборудования и химической продукции.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0079-4e5f-8a9b-c0d1e2f30079', 'Grundfos', 'Датская компания, один из крупнейших в мире производителей насосного оборудования.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0080-4e5f-8a9b-c0d1e2f30080', 'Illinois Tool Works', 'Американский многоотраслевой производитель промышленного оборудования, крепежа и упаковочных систем.', '2024-01-08 08:00:00+03', '2024-01-08 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0081-4e5f-8a9b-c0d1e2f30081', 'Tyco Electronics', 'Американский производитель электронных компонентов, соединителей и сенсорных систем.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0082-4e5f-8a9b-c0d1e2f30082', 'Sulzer', 'Швейцарская инжиниринговая компания, специализирующаяся на насосах, смесительных и разделительных технологиях.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0083-4e5f-8a9b-c0d1e2f30083', 'Hologic', 'Американская медицинская компания, производитель диагностического оборудования и хирургических инструментов.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0084-4e5f-8a9b-c0d1e2f30084', 'Roper Technologies', 'Американская промышленная компания, производитель диверсифицированного оборудования и программного обеспечения.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0085-4e5f-8a9b-c0d1e2f30085', 'Alfa Laval', 'Шведская компания, производитель теплообменников, сепараторов и насосного оборудования для промышленности.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0086-4e5f-8a9b-c0d1e2f30086', 'Spirent', 'Британская технологическая компания, производитель оборудования для тестирования телекоммуникационных сетей.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0087-4e5f-8a9b-c0d1e2f30087', 'Endress+Hauser', 'Швейцарская компания, производитель приборов для измерения уровня, расхода, давления и качества жидкостей.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0088-4e5f-8a9b-c0d1e2f30088', 'Keysight Technologies', 'Американская компания, производитель электронных измерительных приборов и программного обеспечения.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0089-4e5f-8a9b-c0d1e2f30089', 'Fluke', 'Американская компания, производитель портативных электронных тестовых и измерительных инструментов.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0090-4e5f-8a9b-c0d1e2f30090', 'Victron Energy', 'Нидерландская компания, производитель систем автономного электропитания, инверторов и зарядных устройств.', '2024-01-09 08:00:00+03', '2024-01-09 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0091-4e5f-8a9b-c0d1e2f30091', 'Makita', 'Японский производитель электроинструментов, садовой техники и промышленного оборудования.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0092-4e5f-8a9b-c0d1e2f30092', 'Hilti', 'Лихтенштейнская компания, производитель профессионального строительного и монтажного инструмента.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0093-4e5f-8a9b-c0d1e2f30093', 'DeWalt', 'Американский производитель профессионального электроинструмента, аккумуляторных устройств и аксессуаров.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0094-4e5f-8a9b-c0d1e2f30094', 'Stanley Black & Decker', 'Американский производитель ручного и электроинструмента, промышленного оборудования и крепёжных изделий.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0095-4e5f-8a9b-c0d1e2f30095', 'Trimble', 'Американская компания, производитель геодезического оборудования, GPS-систем и программного обеспечения.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0096-4e5f-8a9b-c0d1e2f30096', 'KUKA', 'Немецкий производитель промышленных роботов и автоматизированных производственных систем.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0097-4e5f-8a9b-c0d1e2f30097', 'Yaskawa', 'Японская компания, производитель промышленных роботов, частотных преобразователей и сервосистем.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0098-4e5f-8a9b-c0d1e2f30098', 'Hamamatsu Photonics', 'Японская компания, производитель оптических датчиков, лазеров и медицинского диагностического оборудования.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0099-4e5f-8a9b-c0d1e2f30099', 'Ametek', 'Американская компания, производитель электронных инструментов и электромеханических устройств для промышленности.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0100-4e5f-8a9b-c0d1e2f30100', 'Cognex', 'Американская компания, мировой лидер в области машинного зрения и промышленных систем идентификации.', '2024-01-10 08:00:00+03', '2024-01-10 08:00:00+03');
INSERT INTO public.manufacturers VALUES ('a1b2c3d4-0001-4e5f-8a9b-c0d1e2f30001', 'Тоета', 'Японский автопроизводитель, основанный в 1937 году. Один из крупнейших производителей автомобилей в мире. 123', '2024-01-01 08:00:00+03', '2026-03-08 17:31:24.776389+03');
INSERT INTO public.manufacturers VALUES ('cb8c1726-7f30-4bdd-a0f1-bf9eb77dc414', 'Новый производитель', 'Новый производитель', '2026-03-08 17:49:28.102749+03', '2026-03-08 17:49:28.102749+03');


--
-- TOC entry 5038 (class 0 OID 58507)
-- Dependencies: 222
-- Data for Name: nomenclatures; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.nomenclatures VALUES ('2b097ac2-937a-40ff-b65b-6768368eddf3', 'https://s3.twcstorage.ru/equipment-warehouse/714fb607-c3e1-4b4a-94b2-632cb98616ed.jpg', 'No caption', '66666666-6666-6666-6666-666666666666', 'a1b2c3d4-0015-4e5f-8a9b-c0d1e2f30015', 'BioMech 3000', '54792df9-b501-4b2b-ab8d-cc59bbd36a82', 1111.00, '2026-03-11 23:42:35.736408+03', '2026-03-11 23:42:35.736409+03', 'RUB');
INSERT INTO public.nomenclatures VALUES ('64853c97-b559-4786-bd03-dcd924a93eec', 'https://s3.twcstorage.ru/equipment-warehouse/a2da6213-ea4e-40d7-bfa5-490e6680a82e.jpg', 'No caption', 'e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5', 'a1b2c3d4-0043-4e5f-8a9b-c0d1e2f30043', 'CyberLift HD', '2a39d66a-5742-4b60-b3a0-1ebaca14077c', 43243.00, '2026-03-11 23:43:44.150088+03', '2026-03-11 23:43:44.150088+03', 'RUB');
INSERT INTO public.nomenclatures VALUES ('2e8de6f6-8e11-435c-9918-58b7994361a1', 'https://s3.twcstorage.ru/equipment-warehouse/9a468483-20b9-4da3-b593-62f788b69a72.jpg', 'No caption', '7e8f9a0b-7e8f-7e8f-7e8f-7e8f9a0b1c2d', 'a1b2c3d4-0056-4e5f-8a9b-c0d1e2f30056', 'DigiForge Pro', 'bda8fb88-7963-4b8f-af7c-20a970eacb7c', 3253.00, '2026-03-11 23:44:28.709163+03', '2026-03-11 23:44:28.709163+03', 'RUB');
INSERT INTO public.nomenclatures VALUES ('9fbddd97-1c25-4498-8ec0-9d2d11f243e3', 'https://s3.twcstorage.ru/equipment-warehouse/935b9a53-9d26-44e8-97be-28722f405a2a.jpg', 'No caption', '0f1a2b3c-0f1a-0f1a-0f1a-0f1a2b3c4d5e', 'a1b2c3d4-0057-4e5f-8a9b-c0d1e2f30057', 'EchoVolt Z', '54792df9-b501-4b2b-ab8d-cc59bbd36a82', 4546.00, '2026-03-11 23:45:29.707396+03', '2026-03-11 23:45:29.707396+03', 'RUB');
INSERT INTO public.nomenclatures VALUES ('16225956-7ef9-4180-b025-ac41b3247a2c', 'https://s3.twcstorage.ru/equipment-warehouse/71a9bfa9-a766-48ab-a80e-abe64853a6d1.jpg', 'No caption', '2f3a4b5c-2f3a-2f3a-2f3a-2f3a4b5c6d7e', 'a1b2c3d4-0075-4e5f-8a9b-c0d1e2f30075', 'FusionPulse S', '2a39d66a-5742-4b60-b3a0-1ebaca14077c', 344.00, '2026-03-11 23:46:24.151092+03', '2026-03-11 23:46:24.151092+03', 'RUB');
INSERT INTO public.nomenclatures VALUES ('d21f5906-b50e-4fe5-9a91-29b3fdad499e', 'https://s3.twcstorage.ru/equipment-warehouse/7523d92b-f8d8-4d91-98ef-1a7ea144bbb6.jpg', 'No caption', '22222222-2222-2222-2222-222222222222', 'a1b2c3d4-0014-4e5f-8a9b-c0d1e2f30014', 'AetherCore X1', '2a39d66a-5742-4b60-b3a0-1ebaca14077c', 123.00, '2026-03-11 23:42:06.334398+03', '2026-03-11 23:42:06.334465+03', 'RUB');
INSERT INTO public.nomenclatures VALUES ('5664210d-6329-4277-ba08-0c9b8469f36e', 'https://s3.twcstorage.ru/equipment-warehouse/46ba21f0-b28b-43e5-8188-2b0c433cefc0.jpg', 'No caption', '22222222-2222-2222-2222-222222222222', 'a1b2c3d4-0014-4e5f-8a9b-c0d1e2f30014', 'Тест', 'bda8fb88-7963-4b8f-af7c-20a970eacb7c', 324.00, '2026-03-12 15:19:28.325149+03', '2026-03-12 15:19:28.325149+03', 'RUB');
INSERT INTO public.nomenclatures VALUES ('11489445-e43b-46ee-b65b-e75be41ac786', 'https://s3.twcstorage.ru/equipment-warehouse/47bf01d9-08ca-4219-aeb9-0f9b78cd5f58.jpg', 'No caption', '22222222-2222-2222-2222-222222222222', 'a1b2c3d4-0007-4e5f-8a9b-c0d1e2f30007', 'Значение модели', '2a39d66a-5742-4b60-b3a0-1ebaca14077c', 13224.00, '2026-03-12 15:30:57.842408+03', '2026-03-12 15:30:57.842409+03', 'RUB');
INSERT INTO public.nomenclatures VALUES ('d9434a18-c8c7-4f9a-8eca-3bfb99f575e4', 'https://s3.twcstorage.ru/equipment-warehouse/6ea69a57-56eb-460e-be36-55a46d574d96.jpg', 'No caption', '15d94efb-feab-490b-b159-fc21b7096b7f', 'a1b2c3d4-0007-4e5f-8a9b-c0d1e2f30007', 'no Test', '54792df9-b501-4b2b-ab8d-cc59bbd36a82', 34535.00, '2026-03-12 15:17:54.159194+03', '2026-03-12 15:17:54.159194+03', 'RUB');


--
-- TOC entry 4884 (class 2606 OID 58548)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 4873 (class 2606 OID 58484)
-- Name: countries PK_countries; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.countries
    ADD CONSTRAINT "PK_countries" PRIMARY KEY ("Id");


--
-- TOC entry 4875 (class 2606 OID 58495)
-- Name: device_types PK_device_types; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.device_types
    ADD CONSTRAINT "PK_device_types" PRIMARY KEY ("Id");


--
-- TOC entry 4877 (class 2606 OID 58506)
-- Name: manufacturers PK_manufacturers; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manufacturers
    ADD CONSTRAINT "PK_manufacturers" PRIMARY KEY ("Id");


--
-- TOC entry 4882 (class 2606 OID 58523)
-- Name: nomenclatures PK_nomenclatures; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.nomenclatures
    ADD CONSTRAINT "PK_nomenclatures" PRIMARY KEY ("Id");


--
-- TOC entry 4878 (class 1259 OID 58539)
-- Name: IX_nomenclatures_CountryId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_nomenclatures_CountryId" ON public.nomenclatures USING btree ("CountryId");


--
-- TOC entry 4879 (class 1259 OID 58540)
-- Name: IX_nomenclatures_DeviceTypeId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_nomenclatures_DeviceTypeId" ON public.nomenclatures USING btree ("DeviceTypeId");


--
-- TOC entry 4880 (class 1259 OID 58541)
-- Name: IX_nomenclatures_ManufacturerId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_nomenclatures_ManufacturerId" ON public.nomenclatures USING btree ("ManufacturerId");


--
-- TOC entry 4885 (class 2606 OID 58524)
-- Name: nomenclatures FK_nomenclatures_countries_CountryId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.nomenclatures
    ADD CONSTRAINT "FK_nomenclatures_countries_CountryId" FOREIGN KEY ("CountryId") REFERENCES public.countries("Id") ON DELETE RESTRICT;


--
-- TOC entry 4886 (class 2606 OID 58529)
-- Name: nomenclatures FK_nomenclatures_device_types_DeviceTypeId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.nomenclatures
    ADD CONSTRAINT "FK_nomenclatures_device_types_DeviceTypeId" FOREIGN KEY ("DeviceTypeId") REFERENCES public.device_types("Id") ON DELETE RESTRICT;


--
-- TOC entry 4887 (class 2606 OID 58534)
-- Name: nomenclatures FK_nomenclatures_manufacturers_ManufacturerId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.nomenclatures
    ADD CONSTRAINT "FK_nomenclatures_manufacturers_ManufacturerId" FOREIGN KEY ("ManufacturerId") REFERENCES public.manufacturers("Id") ON DELETE RESTRICT;


-- Completed on 2026-03-13 13:07:08

--
-- PostgreSQL database dump complete
--

\unrestrict VFtBmnMZKmg82W9kCDzSfZ4QO5Hj8yohn71gqMm2OOXHz2ollb0urhuncVRflqE

