def AnalyzeNumbers(Array<Integer> numbers):
    primeCounter = 0
    oddCounter = 0
    evenCounter = 0
    for number in numbers:
        if CheckPrime(number):
            primeCounter = primeCounter + 1
        else:
            if num % 2 == 0:
                evenCounter = evenCounter + 1
            else:
                oddCounter = oddCounter + 1
    
    return primeCounter, oddCounter, evenCounter
