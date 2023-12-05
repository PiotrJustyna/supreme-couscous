# supreme-couscous

argon + secrets management

## start

`./start.sh`

## exit

* `exit`:
  * detaches from argon shell
  * stops argon container
* [optional] `docker compose down`:
  * stops and removes the development stack
  * execute only if you want to get rid of the whole stack
  * you can keep the stack alive even when you exit and shut down the argon container and when you're ready to start argon again, running `./start.sh` is just going to start argon - the rest of the stack is already running.
  * your workflow could look like this: `./start.sh` -> exit -> `./start.sh` -> exit -> `./start.sh` -> `...` 