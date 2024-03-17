# Arguments
ARG PG_VERSION
ARG PG_DATABASE
ARG PG_USER
ARG PG_PASSWORD

# Init image
FROM postgres:PG_VERSION

# Environment
ENV POSTGRES_DB=PG_DATABASE
ENV POSTGRES_USER=PG_USER
ENV POSTGRES_PASSWORD=PG_PASSWORD

# Copy sql script into container
COPY ./init.sql /docker-entrypoint-initdb.d/

# Expose port 5432
EXPOSE 5432
