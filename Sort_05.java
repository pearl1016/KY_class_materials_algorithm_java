package newalgorithm;  // 패키지 선언

import java.util.Scanner;
import java.util.Random;

public class Sort_05 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        // 사용자에게 배열 크기 입력받기
        System.out.print("[버블,퀵,합병 알고리즘: 알고리즘을 구현하고 수행속도를 측정하라]");
        System.out.println(" ");
        System.out.print("배열의 크기를 입력하세요: ");
        int size = scanner.nextInt();
        System.out.println(" ");
        
        // 배열 선언 및 랜덤 숫자로 초기화
        int[] array = new int[size];
        System.out.println(size + "개의 랜덤 숫자를 생성합니다:");
        for (int i = 0; i < size; i++) {
            array[i] = random.nextInt(101);  // 0부터 100까지의 랜덤 숫자
            System.out.print(array[i] + " ");
        }
        System.out.println();  // 줄바꿈
        System.out.println(" ");

        // 버블 정렬 수행 및 시간 측정
        int[] bubbleArray = array.clone();  // 원본 배열 복제
        long startTime = System.nanoTime();
        bubbleSort(bubbleArray);
        long endTime = System.nanoTime();
        printArray("버블 정렬된 배열:", bubbleArray);
        System.out.println("버블 정렬 수행 시간: " + (endTime - startTime) + " 나노초");
        System.out.println(" ");
        
        // 퀵 정렬 수행 및 시간 측정
        int[] quickArray = array.clone();  // 원본 배열 복제
        startTime = System.nanoTime();
        quickSort(quickArray, 0, quickArray.length - 1);
        endTime = System.nanoTime();
        printArray("퀵 정렬된 배열:", quickArray);
        System.out.println("퀵 정렬 수행 시간: " + (endTime - startTime) + " 나노초");
        System.out.println(" ");
        
        // 합병 정렬 수행 및 시간 측정
        int[] mergeArray = array.clone();  // 원본 배열 복제
        startTime = System.nanoTime();
        mergeSort(mergeArray, 0, mergeArray.length - 1);
        endTime = System.nanoTime();
        printArray("합병 정렬된 배열:", mergeArray);
        System.out.println("합병 정렬 수행 시간: " + (endTime - startTime) + " 나노초");
    }

    // 버블 정렬 메소드
    public static void bubbleSort(int[] array) {
        int n = array.length;
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - 1 - i; j++) {
                if (array[j] > array[j + 1]) {
                    // swap
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    // 퀵 정렬 메소드
    public static void quickSort(int[] array, int low, int high) {
        if (low < high) {
            int pi = partition(array, low, high);
            quickSort(array, low, pi - 1);  // 재귀적으로 왼쪽 부분 정렬
            quickSort(array, pi + 1, high); // 재귀적으로 오른쪽 부분 정렬
        }
    }

    // 배열의 파티션을 수행하는 메소드
    private static int partition(int[] array, int low, int high) {
        int pivot = array[high];  // 피벗으로 배열의 마지막 요소 선택
        int i = (low - 1); // 피벗보다 작은 요소의 인덱스
        
        for (int j = low; j < high; j++) {
            if (array[j] <= pivot) {
                i++;
                // swap
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // 피벗을 적절한 위치에 배치
        int temp = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp;

        return i + 1;
    }

    // 합병 정렬 메소드
    public static void mergeSort(int[] array, int left, int right) {
        if (left < right) {
            int mid = (left + right) / 2;
            
            // 왼쪽과 오른쪽 부분으로 나누기
            mergeSort(array, left, mid);
            mergeSort(array, mid + 1, right);
            
            // 병합
            merge(array, left, mid, right);
        }
    }

    // 배열을 병합하는 메소드
    private static void merge(int[] array, int left, int mid, int right) {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        
        // 왼쪽과 오른쪽 배열 생성
        int[] L = new int[n1];
        int[] R = new int[n2];
        
        // 데이터 복사
        System.arraycopy(array, left, L, 0, n1);
        System.arraycopy(array, mid + 1, R, 0, n2);
        
        // 병합
        int i = 0, j = 0;
        int k = left;
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                array[k++] = L[i++];
            } else {
                array[k++] = R[j++];
            }
        }
        
        // 남은 요소 복사
        while (i < n1) {
            array[k++] = L[i++];
        }
        while (j < n2) {
            array[k++] = R[j++];
        }
    }

    // 배열 출력 메소드
    public static void printArray(String message, int[] array) {
        System.out.println(message);
        for (int num : array) {
            System.out.print(num + " ");
        }
        System.out.println();  // 줄바꿈
    }
}
