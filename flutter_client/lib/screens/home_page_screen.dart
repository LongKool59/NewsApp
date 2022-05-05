import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class HomeScreen extends ConsumerWidget {
  @override
  Widget build(BuildContext context, ScopedReader watch) {
    return const SafeArea(
      child: Scaffold(
        body: Center(
          child: Text('Hello World'),
        ),
      ),
    );
  }
}
