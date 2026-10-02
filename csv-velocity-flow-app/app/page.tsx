'use client';

import { Menu, LayoutDashboard, Settings } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetTrigger } from '@/components/ui/sheet';
import { useAppStore, ActiveView } from '@/store/useAppStore';
import { DashboardView, SettingsView } from '@/components/Views';

export default function Home() {
  const { activeView, isMenuOpen, setActiveView, setMenuOpen } = useAppStore();

  const renderView = () => {
    switch (activeView) {
      case 'dashboard':
        return <DashboardView />;
      case 'settings':
        return <SettingsView />;
      default:
        return <DashboardView />;
    }
  };

  const NavigationLinks = () => (
      <nav className="flex flex-col gap-2 mt-4">
        <Button
            variant={activeView === 'dashboard' ? 'default' : 'ghost'}
            className="justify-start gap-2"
            onClick={() => setActiveView('dashboard')}
        >
          <LayoutDashboard className="h-4 w-4" />
          Dashboard
        </Button>
        <Button
            variant={activeView === 'settings' ? 'default' : 'ghost'}
            className="justify-start gap-2"
            onClick={() => setActiveView('settings')}
        >
          <Settings className="h-4 w-4" />
          Ustawienia
        </Button>
      </nav>
  );

  return (
      <div className="min-h-screen flex flex-col bg-background text-foreground">
        {/* Pasek nawigacji (Header) */}
        <header className="sticky top-0 z-40 border-b bg-background/95 backdrop-blur px-4 py-3 flex items-center justify-between">
          <div className="flex items-center gap-4">
            {/* Menu Hamburgerowe dla urządzeń mobilnych (Shadcn UI Sheet) */}
            <Sheet open={isMenuOpen} onOpenChange={setMenuOpen}>
              <SheetTrigger asChild>
                <Button variant="outline" size="icon" className="md:hidden">
                  <Menu className="h-5 w-5" />
                  <span className="sr-only">Otwórz menu</span>
                </Button>
              </SheetTrigger>
              <SheetContent side="left" className="w-[240px]">
                <SheetHeader>
                  <SheetTitle className="text-left">Nawigacja</SheetTitle>
                </SheetHeader>
                <NavigationLinks />
              </SheetContent>
            </Sheet>

            <h1 className="font-bold text-xl tracking-tight">AppDemo</h1>
          </div>

          <div className="hidden md:flex gap-4">
            <Button
                variant={activeView === 'dashboard' ? 'secondary' : 'ghost'}
                onClick={() => setActiveView('dashboard')}
            >
              Dashboard
            </Button>
            <Button
                variant={activeView === 'settings' ? 'secondary' : 'ghost'}
                onClick={() => setActiveView('settings')}
            >
              Ustawienia
            </Button>
          </div>
        </header>

        <main className="flex-1 p-4 md:p-8 max-w-4xl mx-auto w-full">
          {renderView()}
        </main>
      </div>
  );
}
