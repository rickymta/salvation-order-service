create database order_db;

\c order_db;

create table payment_methods (
	id character varying(50) not null primary key,
	name character varying,
	description character varying,
	dode character varying,
	admin_id character varying,
	created_at timestamp without time zone,
	updated_at timestamp without time zone,
	status integer
);

create table transports (
	id character varying(50) not null primary key,
	name character varying,
	description character varying,
	code character varying,
	price bigint,
	admin_id character varying,
	created_at timestamp without time zone,
	updated_at timestamp without time zone,
	status integer
);

create table vouchers (
	id character varying(50) not null primary key,
	voucher_code character varying,
	sale integer,
	quantity integer,
	admin_id character varying,
	created_at timestamp without time zone,
	updated_at timestamp without time zone,
	status integer
);

create table orders (
	id character varying(50) not null primary key,
	order_code character varying,
	account_id character varying,
	full_name character varying,
	phone_number character varying,
	address character varying,
	total_amount bigint,
	total_sale bigint,
	transport_id character varying,
	transport_code character varying,
	payment_id character varying,
	payment_code character varying,
	voucher_id character varying,
	voucher_sale character varying,
	created_at timestamp without time zone,
	updated_at timestamp without time zone,
	status integer,
	CONSTRAINT fk_transport_id
      FOREIGN KEY(transport_id) 
        REFERENCES transports(id),
	CONSTRAINT fk_payment_id
      FOREIGN KEY(payment_id) 
        REFERENCES payment_methods(id),
	CONSTRAINT fk_voucher_id
      FOREIGN KEY(voucher_id) 
        REFERENCES vouchers(id)
);

create table order_details (
	id character varying(50) not null primary key,
	order_id character varying,
	product_id character varying,
	product_name character varying,
	product_feature_image character varying,
	product_quantity integer,
	total_price bigint,
	product_sale integer,
	total_sale_price bigint,
	created_at timestamp without time zone,
	updated_at timestamp without time zone,
	status integer,
	CONSTRAINT fk_order_id
      FOREIGN KEY(order_id) 
        REFERENCES orders(id)
);