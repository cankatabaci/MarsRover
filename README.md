# MarsRover

[![Build Status](https://travis-ci.com/cankatabaci/MarsRover.svg?branch=master)](https://travis-ci.com/cankatabaci/MarsRover)

## Problemin Tanımı

Mars platosunda gezme görevinde bulunan bir robotu, NASA'nın yolladığı basit harf ve rakamlar ile kontrol etmek. Örnek bir konum olarak 0 0 N, Robotun sol at köşede durduğunu ve yönünün Kuzey olduğunu anlatır. Robotu yönlendirmek için NASA'nın yollayacağı 3 çeşit harf var, bunlar L, R, M. L ve R'nin anlamları, 90 derece sola ve sağa dönmeleri, M ise bulunduğu konumda hareket etmesi. (x,y)'nin direkt kuzeyindeki karenin (x, y+1) olduğunu varsayıyoruz. Girilen ilk değer, platonun sağ üst satırını temsil eder. Sol alt köşesinin (0,0) olduğunu varsayıyoruz. Test input'larında iki robot için ayrı değerler olacak ve ikinci robot, ilk robotun hareket etmesini beklemeli.

## Input and Output 
Test Input:    
5 5  
1 2 N  
LMLMLMLMM  
3 3 E  
MMRMMRMRRM  

Expected Output:  
1 3 N  
5 1 E  


## Build
> dotnet restore  
> dotnet build  
> dotnet run --project MarsRover/MarsRover.csproj  

## Test
> dotnet test MarsRoverTest/MarsRoverTest.csproj
 
## Proje Hiyerarşisi 

Constans/UserMessages.cs: Used to store meaningful messages to be forwarded to the user    
Enums/Compass.cs: A classic compass is used to describe the main directions.    
Enums/Moves.cs: Movement definitions that the Rover can make  
BusinessLayer/Plateau.cs: To describe the world the Rover is on    
BusinessLayer/Rover.cs: Performs the basic movements of the Rover  
