#!/bin/bash

$(kubectl -n rabbits port-forward --address 0.0.0.0 rabbitmq-0 8080:15672) 1> rabbitmq.log 2> rabbitmq.error &

exit 0
