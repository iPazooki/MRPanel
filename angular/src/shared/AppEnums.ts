import { TenantAvailabilityState, PageType } from '@shared/service-proxies/service-proxies';


export class AppTenantAvailabilityState {
    static Available: number = TenantAvailabilityState._1;
    static InActive: number = TenantAvailabilityState._2;
    static NotFound: number = TenantAvailabilityState._3;
}

export class AppPageType {
    static Page: number = PageType._0;
    static News: number = PageType._1;
    static Article: number = PageType._2;
}
