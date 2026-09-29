<template>
  <v-app>
    <!-- Pasek boczny (Sidebar) -->
    <v-navigation-drawer permanent elevation="2">
      <v-list-item title="Moja Aplikacja"
                   subtitle="Nuxt 3 + Vuetify"></v-list-item>
      <v-divider></v-divider>
      <v-list density="compact" nav>
        <!-- NuxtLink integruje się bezpośrednio z
        komponentami Vuetify poprzez atrybut to -->
        <v-list-item prepend-icon="mdi-home"
                     title="Strona Główna" to="/"></v-list-item>
        <v-list-item prepend-icon="mdi-cog"
                     title="Ustawienia" to="/settings"></v-list-item>
      </v-list>
    </v-navigation-drawer>
    <!-- Pasek górny (Navbar) -->
    <v-app-bar title="Panel zarządzania">
      <template v-slot:append>
<span class="mr-4">Zalogowany jako: <strong>{{
    sessionStore.user.value.name }}</strong></span>
      </template>
    </v-app-bar>
    <!-- Główna przestrzeń na widoki z routingu -->
    <v-main>
      <v-container fluid>
        vue nuxt jak zrobić by projekt podzielony był na widkoki miał komponenyt oraz folder z widokami ... about:reader?url=https%3A%2F%2Fwww.google.com%2Fsearch%3Fq%3Dvue%2Bnuxt%2Bjak%...
        2 z 5 28.09.2026, 15:51<slot />
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup>

import { provide, ref } from 'vue'

// Prosty mechanizm DI i zarządzania sesją (odpowiednik Signals / useState)
const user = ref({ name: 'Jan Kowalski', role: 'Admin'})
const logout = () => { user.value.name = 'Gość' }
const sessionStore = { user, logout }

// Wstrzykiwanie zależności (DI) - udostępniamy serwis dla wszystkich komponentów-dzieci
provide('sessionService', sessionStore)

</script>