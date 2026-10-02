import { IService } from "@/domain/interfaces/IService";

class AbcService implements IService {
    getAbc(): string {
        return "Jan Kowalski";
    }
}