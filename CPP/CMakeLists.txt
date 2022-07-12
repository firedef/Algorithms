cmake_minimum_required(VERSION 3.22)
project(CPP)

set(CMAKE_CXX_STANDARD 23)

file(GLOB_RECURSE SRC_FILES src/*.cpp src/*.c src/*.hpp src/*.h)

add_executable(CPP main.cpp ${SRC_FILES})
