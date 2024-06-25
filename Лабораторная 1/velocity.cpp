#include <iostream>
using namespace std;

double calculate_velocity(double t) {
    return 3 * t * t - 6 * t;
}

int main() {
    setlocale(LC_ALL, "rus");
    double t;
    cout << "Введите значение времени t: ";
    cin >> t;
    double velocity = calculate_velocity(t);
    cout << "Скорость тела в момент времени t = " << t << ": " << velocity << endl;
    return 0;
}