# Redis tutorial

## Basics

1. start first Redis container with

~~~sh
docker run --name my-first-redis -d redis

// or  

docker run --name my-first-redis -p [port_number]:6379 -d redis
~~~

2. open an interactive shell on the first container

~~~sh
docker exec -it my-first-redis sh
~~~

3. run the Redis CLI
~~~sh
redis-cli
~~~

4. create a key value pair
~~~
set name foo
~~~

5. quit the Redis CLI with `quit` and the interactive shell with `exit`

6. start second Redis container with and link it to the first container (name will be redis)
~~~sh
docker run -it --rm --name my-second-redis --link my-first-redis:redis -d redis`
~~~

7. open an interactive shell on the second redis container with
~~~sh
docker exec -it my-second-redis sh
~~~

8. open the redis cli on the host (the 1st redis container named redis)
~~~sh
redis-cli -h redis
or
redis-cli -h [host or IP] -p [port_number] -a [password]
~~~

9. get the value for the key _name_ with `get name`