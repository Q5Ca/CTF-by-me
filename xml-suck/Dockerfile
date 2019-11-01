FROM php:7.0.30-apache-stretch
RUN apt update
RUN apt install -y iptables
COPY entrypoint.sh /entrypoint.sh
ENTRYPOINT [ "/entrypoint.sh" ]
CMD [ "tail", "-f", "/var/log/apache2/access.log" ]