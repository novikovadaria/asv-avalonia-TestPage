# asv-avalonia-TestPage

This is a sample ViewModel for a page implemented using Asv.Avalonia, demonstrating basic text input handling, validation, reactive properties, and commands.

## Overview
TestPageViewModel provides a simple interface for entering text, displaying it, and clearing it, built with reactive properties and commands:

InputText — input text property with change history.

OutputText — displayed output text.

StringProp — string property with validation (cannot be empty).

## Commands:

ShowTextCommand — copies the input text to the output.

ClearTextCommand — clears both input and output text.

Clear — clears StringProp text, enabled only if StringProp is not empty.

## Features
Uses ReactiveProperty for reactive UI updates.

Validates input with HistoricalStringProperty.

Supports change history for input strings.

Dependency injection via MEF (Managed Extensibility Framework).

Async reactive commands.

Proper resource cleanup and subscription disposal.

## Technologies Used
Asv.Avalonia — MVVM framework for Avalonia with reactive extensions.

Reactive Extensions (R3).

Material Icons for UI icons.

MEF for dependency injection.

## Structure
TestPageViewModel.cs — main ViewModel logic.

## Properties:

InputText — input property with history.

OutputText — output property.

StringProp — validated string property.

## Commands:

ShowTextCommand

ClearTextCommand

Clear

## Usage
Bind the ViewModel to your UI
Use TestPageViewModel as the DataContext of the corresponding view (e.g., Avalonia XAML page).

## Text input and display
User enters text into InputText, triggers ShowTextCommand to copy text to OutputText.

## Clear text
Use ClearTextCommand to clear input and output fields.
Use Clear command to clear StringProp.
