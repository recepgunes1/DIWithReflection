#!/bin/bash

# Define the base URL
BASE_URL="http://localhost:5000"

# Fetch the last comment
echo "Fetching the last comment..."
curl "${BASE_URL}/api/Comment/LastComment"
echo -e "\n"

# Count bookings
echo "Counting bookings..."
curl "${BASE_URL}/api/Booking/CountBooking"
echo -e "\n"

# Fetch user name
echo "Fetching user name..."
curl "${BASE_URL}/api/User/UserName"
echo -e "\n"
