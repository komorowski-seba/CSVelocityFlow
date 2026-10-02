'use client';

import React, { createContext, useContext } from 'react';
import { IUserService, UserService, MockUserService } from '@/services/UserService';

interface IDIContainer {
    userService: IUserService;
}

const DIContext = createContext<IDIContainer | null>(null);

export function DIProvider({ children }: { children: React.ReactNode }) {

    const isDevelopment = process.env.NODE_ENV === 'development';

    const container: IDIContainer = {
        userService: isDevelopment ? new MockUserService() : new UserService(),
    };

    return (
        <DIContext.Provider value={container}>
            {children}
        </DIContext.Provider>
    );
}

export function useDependencies() {
    const context = useContext(DIContext);
    if (!context) {
        throw new Error('useDependencies musi być użyty wewnątrz DIProvider');
    }
    return context;
}

/*
export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="pl">
      <body>
        <DIProvider>
            {children}
        </DIProvider>
      </body>
    </html>
    );
}


import { useDependencies } from '@/context/DIContext';

export function DashboardView() {
  // Wstrzyknięcie zależności prosto z kontekstu aplikacji!
  const { userService } = useDependencies();
  const userName = userService.getUserName();

  return (
    <div className="p-6 bg-card rounded-lg border shadow-sm">
      <h2 className="text-2xl font-bold mb-2">Pulpit (Dashboard)</h2>
      <p className="text-muted-foreground">
        Witaj, <span className="font-semibold text-foreground">{userName}</span>!
      </p>
    </div>
  );
}

 */
