#include <stdexcept>

extern "C" _declspec(dllexport) double Add(double a, double b)
{
	return a + b;
}

extern "C" _declspec(dllexport) double Substract(double a, double b)
{
	return a - b;
}

extern "C" _declspec(dllexport) double Multiply(double a, double b)
{
	return a * b;
}

extern "C" _declspec(dllexport) double Divide(double a, double b)
{
	if (b == 0)
		throw std::invalid_argument("b cannot be zero!");
	return a / b;
}