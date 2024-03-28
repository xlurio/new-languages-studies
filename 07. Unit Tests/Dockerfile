FROM php:8.3.4-cli

# Phive
RUN wget -O phive.phar https://phar.io/releases/phive.phar
RUN wget -O phive.phar.asc https://phar.io/releases/phive.phar.asc
RUN gpg --keyserver hkps://keys.openpgp.org --recv-keys 0x9D8A98B29B2D5D79
RUN gpg --verify phive.phar.asc phive.phar
RUN chmod +x phive.phar
RUN mv phive.phar /usr/local/bin/phive

# PHPUnit
RUN phive install phpunit

# Autoload Builer
RUN phive install phpab

# Copy source files
WORKDIR /app/
COPY src /app/src
COPY tests /app/tests
