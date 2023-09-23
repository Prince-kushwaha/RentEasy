import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'reviseDate'
})
export class ReviseDatePipe implements PipeTransform {

  transform(str: string|undefined): string|undefined {
    if(str==undefined) return undefined;
    let arr = str.split("-");
    let answer = arr[2] + '-' + arr[1] + '-' + arr[0];
    return answer;
  }

}
