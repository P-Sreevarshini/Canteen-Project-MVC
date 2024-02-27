import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  public apiUrl = 'https://8080-edadeeddfbdaedbcaafcbfcecefbcbacdebdeecab.premiumproject.examly.io'; // replace with your API URL

  constructor(private http: HttpClient) {}

  // makePayment(courseId: number): Observable<any> {
  //   const role = localStorage.getItem('userRole');
  //   console.log(role);

  //   if (role !== 'STUDENT' && role !== 'student') {
  //     console.error('Access denied. Only students can make payments.');
  //     return;
  //   }

  //   const endpoint = `${this.apiUrl}/student/payment`;
  //   const authToken = localStorage.getItem('token');
  //   const headers = authToken ? new HttpHeaders({ 'Authorization': `Bearer ${authToken}` }) : undefined;
  //   const options = { headers };
  //   console.log(headers);

  //   return this.http.post(endpoint, {}, options).pipe(
  //     catchError((error) => {
  //       if (error.status === 401) {
  //         console.error('Authentication error: Redirect to login page or handle accordingly.');
  //       }
  //       return throwError(error);
  //     })
  //   );
  // }
  getAllPayments(paymentData: any): Observable<any> {
    const role = localStorage.getItem('userRole');
    console.log(role);

    if (role !== 'ADMIN' && role !== 'admin') {
      console.error('Access denied. Only students can make payments.');
      return;
    }

    const endpoint = `${this.apiUrl}/admin/course/payment`;
    const authToken = localStorage.getItem('token');
    const headers = authToken ? new HttpHeaders({ 'Authorization': `Bearer ${authToken}` }) : undefined;
    const options = { headers };
    console.log(headers);

    return this.http.get(endpoint, options).pipe(
      catchError((error) => {
        if (error.status === 401) {
          console.error('Authentication error: Redirect to login page or handle accordingly.');
        }
        return throwError(error);
      })
    );
  }

  submitPayment(paymentData: any): Observable<any> {
    const role = localStorage.getItem('userRole');
    console.log(role);
    if (role !== 'STUDENT' && role !== 'student') {
          console.error('Access denied. Only students can make payments.');
          return;
        }
    
        const endpoint = `${this.apiUrl}/student/student/payment`;
        const authToken = localStorage.getItem('token');
        const headers = authToken ? new HttpHeaders({ 'Authorization': `Bearer ${authToken}` }) : undefined;
        const options = { headers };
        console.log(headers);
    
        return this.http.post(endpoint, paymentData , options).pipe(
          catchError((error) => {
            if (error.status === 401) {
              console.error('Authentication error: Redirect to login page or handle accordingly.');
            }
            return throwError(error);
          })
        );

    // return this.http.post<any>(`${this.apiUrl}/student/payment`, paymentData, { headers });
  }
}