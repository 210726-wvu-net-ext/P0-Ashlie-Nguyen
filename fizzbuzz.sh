#!/usr/bin/bash
n=1
while (( "n<=20" ))
do
if [ $((n%3)) = 0 ]  &&  [ $((n%5)) = 0 ]
then
    echo "fizzbuzz"
elif [ $(( n% 3 )) = 0 ]
then
    echo "fizz"
elif  [ $(( n% 5 )) = 0 ]
then
    echo "buzz"
fi
((n++))
done
