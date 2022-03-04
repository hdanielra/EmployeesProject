import { Pipe, PipeTransform } from '@angular/core';
import { IEmployee } from '../interfaces/employees.interfaces';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform( employees: IEmployee[], page: number = 0, search: string = '' ): IEmployee[] {

    // console.log(search);
    if(search.length == 0){
      return employees.slice(page,page + 5);
    }

    const filteredEmployees = employees.filter(emp => emp.Id.toString() == search.trim())
    return filteredEmployees.slice(page,page + 5);
  }

}
