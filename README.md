# Tutorial Redis

1. start first Redis container with 
`docker run --name my-first-redis -d redis`

2. start second Redis container with
`docker run -it --rm --name my-second-redis --link my-first-redis:redis -d redis`

3. open an interactive shell on the second redis container with
`docker exec -it my-second-redis sh`