docker run -d --name tickets_pg -p 5432:5432 --network host -e POSTGRES_DB=tickets -e POSTGRES_USER=tickets -e POSTGRES_PASSWORD=ticketspw
postgres