export function reverseString(str: string) {
    let arr = str.split("-");
    let answer=arr[2]+'-'+arr[1]+'-'+arr[0];
    return answer;
}