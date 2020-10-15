#!/bin/bash

$(kubectl -n rabbits port-forward service/rabbitmq-publisher --address 0.0.0.0 8088:80) 1> app.log 2> app.error &

exit 0
