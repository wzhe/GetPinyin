*GetPinyin* 是一个获取汉字拼音的库

优点：

1. 是速度快

2. 可以获取多音字的多个拼音

   ​

 **缺点**

- 是无法获取音标。

本文的实现完全参考[lucida](http://zh.lucida.me/) 的[从2000毫秒到10毫秒——Lucida拼音库的设计与实现](https://www.tuicool.com/articles/yYBVRb2)一文

c#版：

​	代码文件：[WzhePinyin.cs](./WzhePinYin.cs)

​	测试代码：[PinyinTest.cs](PinyinTest.cs)

c++版 (需要使用 w_char 类型)：

​	单文件：[Pinyin-onefile.cpp](Pinyin-onefile.cpp)

​	头文件与实现分开：[Pinyin.h](Pinyin.h) [Pinyin.cpp](Pinyin.cpp) 