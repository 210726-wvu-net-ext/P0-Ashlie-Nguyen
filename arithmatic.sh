read -p "Enter the number: " number
if [ $(( $number % 2)) = 0 ]
then 
    echo "This is an even number"
else 
    echo "This is an odd number"
fi
read -p "Enter student marks:" marks
if [ "$marks" -lt 41 ]
then
    echo "F"
elif [ "$marks" -gt 40 ] && [ "$marks" -lt 51 ]
then
    echo "D"
elif [ "$marks" -gt 50 ] && [ "$marks" -lt 61 ]
then
    echo "C"
elif [ "$marks" -gt 60 ] && [ "$marks" -lt 71 ] 
then
    echo "B"
else [ "$marks" -gt 70 ]
    echo "A"
fi