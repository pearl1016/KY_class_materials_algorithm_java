package algorithm;



public class Hanoi {

    public static void main(String[] args) {

        hanoi(4, 'A', 'B', 'C');

    }



    private static void hanoi(int n, char from, char by, char to) {

        if (n == 1) {

            System.out.println("Move " + from + " -> " + to);

        } else {

            hanoi(n - 1, from, to, by);

            System.out.println("Move " + from + " -> " + to);

            hanoi(n - 1, by, from, to);

        }

    }

}