#!/bin/bash
service apache2 start
iptables -t filter -I OUTPUT 1 -m state --state NEW -j DROP
exec "$@"