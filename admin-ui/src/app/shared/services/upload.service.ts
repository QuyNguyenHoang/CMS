import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

export  interface UploadResponse {
  path: string;
}

@Injectable()
export class UploadService {
  constructor(private http: HttpClient) {}

  uploadImage(type: string, files: File[]): Observable<UploadResponse> {
    const formData = new FormData();
    formData.append('file', files[0], files[0].name);

    return this.http.post<UploadResponse>(
      `${environment.API_URL}/api/admin/media?type=${type}`,
      formData
    );
  }
}
