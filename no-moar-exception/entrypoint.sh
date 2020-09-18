#!/bin/bash
cd /src
php -S 0.0.0.0:8000
exec "$@"