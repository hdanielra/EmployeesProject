export interface IEmployeesResponse {
  Status:  string;
  Message: string;
  Data:    IEmployee[];
}

export interface IEmployeeByIdResponse {
  Status:  string;
  Message: string;
  Data:    IEmployee;
}


export interface IEmployee {
  Id:                  number;
  EmployeeName:       string;
  EmployeeSalary:     number;
  EmployeeAge:        number;
  ProfileImage:       string;
  EmployeeAnualSalary: number;
}



