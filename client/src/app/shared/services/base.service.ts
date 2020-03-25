import { HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';

export abstract class BaseService {
  public UrlService = environment.api;

  protected ObterHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  }

}
