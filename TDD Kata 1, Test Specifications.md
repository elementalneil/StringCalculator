```
given "" then 0
given "0" then 0
given "1" then 1
given "125" then 125
given "1000" then 1000
given "1001" then 0

given "1,2,3" then 6
given "1001,41" then 41
given "1,2,,3,4" then "Invalid Input"

given "1\n3" then 4
given "1\n0" then 1
given "1\n1,3" then 5
given "1,\n" then "Invalid Input"
given "1000,1000\n15" then 2015
given "1001\n100,100" then 200

given "//|\n1|2|3|4|5" then 15
given "//+\n1+2+3+4+5" then 15
given "//%\n1001%2%3%4%5" then 14
given "//%\n1%2%3%4%5" then 15
given "//;\n1;2,3\n4;5" then 15
given "//,\n1,2\n3,4\n5" then 15
given "//;\n1;;2" then "Invalid Input"
given "//|\n1|2,3|4,5" then "Invalid Input"
given "//-\n5-2" then "Negatives Not Allowed -2"
given "//abc\n1abc2abc3" then 6
given "//;\n1;2,-3;4;5" then "Negatives Not Allowed: -3"

given "//***\n1,2,3" then "InvalidInput"
given "//###\n1###2###3" then 6
given "//++\n1++2++3" then 6
```