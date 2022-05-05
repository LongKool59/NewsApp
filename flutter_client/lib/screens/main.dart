import 'package:flutter/material.dart';
import 'package:flutter_client/screens/home_page_screen.dart';
import 'package:flutter_client/state/state.dart';
import 'package:flutter_client/view_model/main_view_model_imp.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:page_transition/page_transition.dart';

void main() {
  runApp(const ProviderScope(child: MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      onGenerateRoute: (settings) {
        switch (settings.name) {
          case '/home':
            return PageTransition(
                child: HomeScreen(),
                type: PageTransitionType.fade,
                settings: settings);
          default:
            return null;
        }
      },
      home: MainPage(),
    );
  }
}

class MainPage extends ConsumerWidget {
  final accountController = TextEditingController();
  final passwordController = TextEditingController();
  GlobalKey<ScaffoldState> scaffoldKey = GlobalKey<ScaffoldState>();
  final mainViewModel = MainViewModelImp();
  @override
  // ignore: avoid_renaming_method_parameters
  Widget build(BuildContext context, ScopedReader watch) {
    var isLoadingWatch = watch(isLoading).state;

    return SafeArea(
      child: Scaffold(
        key: scaffoldKey,
        backgroundColor: Color(0xFFF1F1F1),
        body: FutureBuilder(
          future: mainViewModel.checkToken(context),
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              return const Center(
                child: CircularProgressIndicator(),
              );
            } else {
              var result = snapshot.data as bool;
              if (result)
                return Container();
              else {
                return isLoadingWatch
                    ? const Center(
                        child: CircularProgressIndicator(),
                      )
                    : Center(
                        child: Padding(
                          padding: EdgeInsets.all(8),
                          child: Card(
                            child: SizedBox(
                                width: MediaQuery.of(context).size.width,
                                height:
                                    MediaQuery.of(context).size.height / 2.5,
                                child: Center(
                                  child: Padding(
                                    padding: const EdgeInsets.all(8),
                                    child: Column(children: [
                                      SizedBox(
                                        height: 30,
                                      ),
                                      Text(
                                        'LOGIN',
                                        style: TextStyle(fontSize: 30),
                                      ),
                                      SizedBox(
                                        height: 10,
                                      ),
                                      TextField(
                                        controller: accountController,
                                        decoration: InputDecoration(
                                          prefixIcon:
                                              Icon(Icons.account_circle),
                                          border: OutlineInputBorder(
                                            borderRadius:
                                                BorderRadius.circular(16),
                                          ),
                                          hintText: 'Email',
                                        ),
                                      ),
                                      SizedBox(
                                        height: 10,
                                      ),
                                      TextField(
                                        controller: passwordController,
                                        obscureText: true,
                                        decoration: InputDecoration(
                                          prefixIcon: Icon(Icons.lock),
                                          border: OutlineInputBorder(
                                            borderRadius:
                                                BorderRadius.circular(16),
                                          ),
                                          hintText: 'Password',
                                        ),
                                      )
                                    ]),
                                  ),
                                )),
                          ),
                        ),
                      );
              }
            }
          },
        ),
      ),
    );
  }
}
