package algorithm;

public class fibonacci_03 {

	public static void main(String[] args) {

        int n = 9; // Fibonacci 수열에서 몇 번째 항까지 계산할지 설정

        long startTime, endTime;



        // 재귀 방식으로 Fibonacci 수열 계산 및 실행 시간 측정

        startTime = System.nanoTime();

        int result = fibonacci(n);

        endTime = System.nanoTime();

        

        System.out.println("Fibonacci (" + n + ") : " + result);

        System.out.println("Execution time: " + (endTime - startTime) + " ns");

    }

    

    // 재귀를 사용한 Fibonacci 수열

    public static int fibonacci(int i) {

        if (i == 1 || i == 2) return 1;

        return fibonacci(i - 1) + fibonacci(i - 2);

    }

}
