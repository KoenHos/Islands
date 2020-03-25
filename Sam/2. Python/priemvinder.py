import time
import os

while True:
 num = int(input("voer een nummer in: "))

 if num > 1:
    for i in range(2,num):
        if (num % i) == 0:
            print(num,"dit is geen priemgetal")
            print(i,"X",num//i,"=",num)


    else:
        print(num,"is een priemgetal")
        time.sleep(5)
        os.system('cls')



 else:
    print(num,"is geen priemgetal")
    print("het is geen priemgetal als je word gespamt")
    time.sleep(10)
    os.system('cls')
