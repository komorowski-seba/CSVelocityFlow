import { create } from 'zustand';

export type ActiveView = 'dashboard' | 'settings';

interface AppState {
    activeView: ActiveView;
    isMenuOpen: boolean;
    setActiveView: (view: ActiveView) => void;
    setMenuOpen: (open: boolean) => void;
}

export const useAppStore = create<AppState>((set) => ({
    activeView: 'dashboard',
    isMenuOpen: false,
    setActiveView: (view) => set({ activeView: view, isMenuOpen: false }),
    setMenuOpen: (open) => set({ isMenuOpen: open }),
}));
